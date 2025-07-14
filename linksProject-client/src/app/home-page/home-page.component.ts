import { Component, OnInit } from '@angular/core';
import { Category} from '../core/models/category.model';
import { CategoryService } from '../core/services/category.service';
import { WebService } from '../core/services/web.service';
import { CommonModule } from '@angular/common';
import { Web } from '../core/models/web.model';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  categories: (Category & { webs?: Web[] })[] = [];
  allWebs: Web[] = [];

  constructor(
    private categoryService: CategoryService,
    private webService: WebService
  ) {}

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe({
      next: (categories) => {
        this.categories = categories.map(c => ({
          ...c,
          icon: this.getIconForCategory(c.name),
          webs: []
        }));

        this.webService.getAllWebs().subscribe({
          next: (webs) => {
            this.allWebs = webs;
            this.categories.forEach(cat => {
              cat.webs = this.allWebs.filter(web => web.idCategory === cat.id);
            });
          },
          error: (err) => console.error('שגיאה בטעינת אתרים:', err)
        });
      },
      error: (err) => console.error('שגיאה בטעינת קטגוריות:', err)
    });
  }

  getIconForCategory(name: string): string {
    const iconsMap: { [key: string]: string } = {
      'בגדים': '👗',
      'טכנולוגיה': '💻',
      'ספרים': '📚',
      'מטבח': '🍳',
      'בריאות': '💊'
    };
    return iconsMap[name] || '📁';
  }

  goToCategory(id: number) {
    alert(`מעבר לקטגוריה ${id}`);
  }
}
