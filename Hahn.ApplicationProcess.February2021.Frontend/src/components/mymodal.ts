import {inject} from 'aurelia-framework';
import {DialogController} from 'aurelia-dialog';

@inject(DialogController)

export class Prompt {
  message: string;
  description: string;
  answer: string;
  controller;

   constructor(controller) {
      this.controller = controller;
      this.answer = null;

      controller.settings.centerHorizontalOnly = true;
   }
   activate({message, description}) {
      this.message = message;
      this.description = description;
   }
}
