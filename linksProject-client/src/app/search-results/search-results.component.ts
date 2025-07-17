import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebService } from '../core/services/web.service';
import { WebDetail } from '../core/models/web-detail.model';
import { CommonModule } from '@angular/common';  // <-- הוספה

@Component({
  selector: 'app-search-results',
  standalone: true,            
  imports: [CommonModule],      
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css']
})
export class SearchResultsComponent implements OnInit {
  searchQuery = '';
  searchResults: WebDetail[] = [];
  loading = false;
  errorMessage = '';
  defaultImageUrl = 'assets/default-image.png';
  searchPerformed = false; 
  constructor(private route: ActivatedRoute, private webService: WebService) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.searchQuery = params['q'] || '';
  
      if (this.searchQuery.trim()) {
        this.performSearch();
      } else {
        this.searchResults = [];
        this.errorMessage = '';
        this.loading = false;
      }
    });
  }
  
  performSearch() {
    this.loading = true;
    this.searchPerformed = true;
    this.errorMessage = '';

    this.webService.searchWebs(this.searchQuery).subscribe({
      next: (results) => {
        this.searchResults = results;
        this.loading = false;

        if (results.length > 0) {
          this.errorMessage = '';
        } else {
          // אם אין תוצאות, אפשר להשאיר את errorMessage ריק כי ההודעה תוצג בתבנית אחרת
        }
      },
      error: (err) => {
        this.errorMessage = `שגיאה בחיפוש עבור: ${this.searchQuery}`;
        this.loading = false;
        this.searchResults = [];
      }
    });
  }
}