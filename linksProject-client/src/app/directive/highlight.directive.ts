import { Directive, ElementRef, Input, OnChanges, Renderer2, SimpleChanges, OnInit } from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: true
})
export class HighlightDirective implements OnChanges, OnInit {
  @Input() appHighlight = false;

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  ngOnInit(): void {
    this.updateHighlight();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['appHighlight']) {
      this.updateHighlight();
      console.log('appHighlight changed:', this.appHighlight);
    }
  }

  private updateHighlight(): void {
    if (this.appHighlight) {
      this.renderer.addClass(this.el.nativeElement, 'highlight-accessibility');
    } else {
      this.renderer.removeClass(this.el.nativeElement, 'highlight-accessibility');
    }
  }
}
