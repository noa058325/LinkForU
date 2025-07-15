import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebService } from '../core/services/web.service';
import { WebDetail } from '../core/models/web-detail.model';
import { CommonModule } from '@angular/common';

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
  defaultImageUrl = 'assets/default-image.png';

  constructor(
    private route: ActivatedRoute,
    private webService: WebService
  ) {}

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam !== null) {
      this.categoryId = +idParam;
      this.webService.getWebsByCategory(this.categoryId).subscribe({
        next: (data: WebDetail[]) => this.webs = data,
        error: (err: any) => console.error('שגיאה בטעינת אתרים לפי קטגוריה:', err)
      });
    }
  }
}