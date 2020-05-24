import { Localization } from './index';

export interface NewsItem {
   id: number;
   isActive: boolean;
   message: Localization;
   url: string;
}