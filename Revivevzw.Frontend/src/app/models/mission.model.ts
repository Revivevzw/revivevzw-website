import { Localization } from './localization.model';

export interface Mission{
   id: number;
   name: Localization;
   country: string;
   description: Localization;
   startDate?: Date;
   endDate?: Date;
   report: Localization;
   interventions: Localization;
   mainImage: string; // URL
   images: string[];
   quote: Localization;
   mediaUrls: string[];
   showReport: boolean;
   type: number;
}