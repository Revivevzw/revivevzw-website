import { Localization } from './localization.model';

export interface Activity {
   id: number;
   name: Localization;
   description: Localization;
   type: number;
   startDate: Date;
   endDate: Date;
   city: string;
   country: string;
   street: string;
   postalCode: string;
   canRegisterOnline: boolean;
}