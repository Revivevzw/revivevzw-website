import { Local } from 'protractor/built/driverProviders';
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
}