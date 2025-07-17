import { Component, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Recommend } from '../core/models/recommend.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-comment',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit, OnDestroy {
  recommends: Recommend[] = [];
  currentIndex = 0;
  likedIds: number[] = [];
  intervalId: any;

  currentUserId: number | null = null;

  // להוספת תגובה חדשה
  newName = '';
  newDescription = '';
  showAddModal = false;

  // לעריכה
  editMode = false;
  editText = '';
  editIndex: number | null = null;

  // הודעות שגיאה
  errorMessage = '';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.currentUserId = this.getCurrentUserId();
    console.log('CurrentUserId:', this.currentUserId);

    this.http.get<Recommend[]>('https://localhost:7091/api/Recommend')
      .subscribe(data => {
        this.recommends = data;
        this.startCarousel();
      });
  }

  getCurrentUserId(): number | null {
    const token = localStorage.getItem('token');
    if (!token) return null;
  
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const userIdString = payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
      return userIdString ? +userIdString : null;
    } catch {
      return null;
    }
  }
  startCarousel() {
    this.intervalId = setInterval(() => {
      this.currentIndex = (this.currentIndex + 1) % this.recommends.length;
    }, 4000);
  }

  like(rec: Recommend) {
    // if (!this.currentUserId) {
    //   this.errorMessage = 'עליך להתחבר כדי לאהוב תגובה';
    //   return;
    // }

    const url = `https://localhost:7091/api/Recommend/${rec.id}/${this.likedIds.includes(rec.id) ? 'unlike' : 'like'}`;
    this.http.post(url, {}).subscribe(() => {
      if (this.likedIds.includes(rec.id)) {
        rec.likesCount--;
        this.likedIds = this.likedIds.filter(id => id !== rec.id);
      } else {
        rec.likesCount++;
        this.likedIds.push(rec.id);
      }
      this.errorMessage = '';
    }, () => {
      this.errorMessage = 'אירעה שגיאה בניסיון לאהוב תגובה';
    });
  }

  openAddModal() {
    if (!this.currentUserId) {
      this.errorMessage = 'עליך להתחבר קודם כדי להוסיף תגובה.';
      return;
    }
    this.errorMessage = '';
    this.newName = '';
    this.newDescription = '';
    this.showAddModal = true;
  }

  closeAddModal() {
    this.showAddModal = false;
    this.errorMessage = '';
  }

  addRecommend() {
    if (!this.currentUserId) {
      this.errorMessage = 'עליך להתחבר קודם כדי להוסיף תגובה.';
      return;
    }
    if (!this.newDescription.trim()) {
      this.errorMessage = 'אנא הכנס טקסט תגובה.';
      return;
    }

    const newRec = {
      name: this.newName || 'משתמש אנונימי',
      description: this.newDescription,
      idUser: this.currentUserId,
      likesCount: 0
    };

    this.http.post<Recommend>('https://localhost:7091/api/Recommend', newRec)
      .subscribe({
        next: (added) => {
          this.recommends.push(added);
          this.newName = '';
          this.newDescription = '';
          this.errorMessage = '';
          this.showAddModal = false;
          this.currentIndex = this.recommends.length - 1;
        },
        error: () => {
          this.errorMessage = 'אירעה שגיאה בהוספת התגובה.';
        }
      });
  }

  isOwner(rec: Recommend): boolean {
    return rec.idUser === this.currentUserId;
  }

  startEdit(index: number) {
    if (!this.isOwner(this.recommends[index])) return;
    this.editText = this.recommends[index].description;
    this.editIndex = index;
    this.editMode = true;
    this.errorMessage = '';
  }

  cancelEdit() {
    this.editMode = false;
    this.editIndex = null;
    this.errorMessage = '';
  }

  updateRecommend() {
    if (this.editIndex === null) return;

    const rec = this.recommends[this.editIndex];
    if (!this.editText.trim()) {
      this.errorMessage = 'התגובה לא יכולה להיות ריקה.';
      return;
    }

    this.http.put(`https://localhost:7091/api/Recommend/${rec.id}`, { description: this.editText })
      .subscribe({
        next: () => {
          this.recommends[this.editIndex!].description = this.editText;
          this.editMode = false;
          this.editIndex = null;
          this.errorMessage = '';
        },
        error: () => {
          this.errorMessage = 'אירעה שגיאה בעדכון התגובה.';
        }
      });
  }

  deleteRecommend(id: number) {
    if (!confirm('האם אתה בטוח שברצונך למחוק את התגובה?')) return;

    this.http.delete(`https://localhost:7091/api/Recommend/${id}`)
      .subscribe(() => {
        this.recommends = this.recommends.filter(r => r.id !== id);
        this.editMode = false;
        this.editIndex = null;
        this.currentIndex = 0;
        this.errorMessage = '';
      }, () => {
        this.errorMessage = 'אירעה שגיאה במחיקת התגובה.';
      });
  }

  next() {
    this.currentIndex = (this.currentIndex + 1) % this.recommends.length;
  }

  prev() {
    this.currentIndex = (this.currentIndex - 1 + this.recommends.length) % this.recommends.length;
  }

  ngOnDestroy(): void {
    clearInterval(this.intervalId);
  }
}
