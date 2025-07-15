import { Web } from "./web.model";

export interface Category {
    id: number;
    name: string;
    icon?: string;
    webs?: Web[]; 
  }
  
  