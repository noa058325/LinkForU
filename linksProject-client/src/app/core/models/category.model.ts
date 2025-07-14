import { Web } from "./web.model";

export interface Category {
    id: number;
    name: string;
    // נוסיף תצוגה ויזואלית זמנית ע"י מיפוי
    icon?: string;
    webs?: Web[]; // נוסיף כאן את רשימת האתרים
  }
  
  