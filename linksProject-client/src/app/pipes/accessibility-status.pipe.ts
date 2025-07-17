import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'accessibilityStatus',
  standalone: true
})
export class AccessibilityStatusPipe implements PipeTransform {
  transform(value: boolean): string {
    return value ? 'נגיש' : 'לא נגיש';
  }
}