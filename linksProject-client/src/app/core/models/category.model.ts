export interface Category {
    id: number;
    name: string;
    // נוסיף תצוגה ויזואלית זמנית ע"י מיפוי
    icon?: string;
    webs?: Web[]; // נוסיף כאן את רשימת האתרים
  }
  
  export interface Web {
    id: number;
    name: string;
    link: string;
    idCategory: number;
  }