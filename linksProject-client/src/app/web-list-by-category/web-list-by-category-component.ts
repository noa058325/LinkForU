import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebService } from '../core/services/web.service';
import { CategoryService } from '../core/services/category.service';
import { WebDetail } from '../core/models/web-detail.model';
import { Category } from '../core/models/category.model';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router'; 

@Component({
  selector: 'app-web-list-by-category',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './web-list-by-category-component.html',
  styleUrls: ['./web-list-by-category-component.css']
})
export class WebListByCategoryComponent implements OnInit {
  webs: WebDetail[] = [];
  categoryId!: number;
  categoryName: string = '';
  defaultImageUrl = 'assets/default-image.png';

  constructor(
    private route: ActivatedRoute,
    private webService: WebService,
    private categoryService: CategoryService,
    private router: Router 
  ) {}
  goHome(): void {
    this.router.navigate(['/']);
  }

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam !== null) {
      this.categoryId = +idParam;

      // שליפת שם הקטגוריה לפי ID
      this.categoryService.getCategories().subscribe({
        next: (categories: Category[]) => {
          const foundCategory = categories.find(c => c.id === this.categoryId);
          this.categoryName = foundCategory?.name || 'קטגוריה';
        },
        error: err => console.error('שגיאה בטעינת קטגוריות:', err)
      });

      // שליפת האתרים לפי הקטגוריה
      this.webService.getWebsByCategory(this.categoryId).subscribe({
        next: (data: WebDetail[]) => this.webs = data,
        error: err => console.error('שגיאה בטעינת אתרים לפי קטגוריה:', err)
      });
    }
  }
}
