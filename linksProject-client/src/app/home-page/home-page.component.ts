import { Component, OnInit } from '@angular/core';
import { Category, Web } from '../core/models/category.model';
import { CategoryService } from '../core/services/category.service';
import { WebService } from '../core/services/web.service';  // ייבוא שירות האתרים
import { CommonModule } from '@angular/common';

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
    private webService: WebService  // הזרקת שירות האתרים
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

            // מיון האתרים לפי קטגוריה
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

  getColorForCategory(name: string): string {
    const cleanedName = name.trim();
    const colorMap: { [key: string]: string } = {
        'ניוזדוס': '#C8E6C9',        
        'אופנה': '#F8BBD0',          
        'מכשירי חשמל': '#D1C4E9',    
        'חינוך': '#BBDEFB',           
        'הומסטיילינג': '#FFE0B2',    
        'מסעדות': '#D7CCC8',          
        'מתכונים': '#B0BEC5',         
        'ארגונים': '#80CBC4',        
        'קיט ונופש': '#FFF59D'        
      };
    
    return colorMap[cleanedName] || '#9E9E9E';
  }

  goToCategory(id: number) {
    alert(`מעבר לקטגוריה ${id}`);
  }
}
