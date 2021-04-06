import { DialogService } from 'aurelia-dialog';
import { Prompt } from '../mymodal';
import { AssetVM } from '../../models/AssetVM';
import { inject } from 'aurelia-framework';
import {
  ValidationControllerFactory,
  ValidationController,
  ValidationRules
} from 'aurelia-validation';
import { BootstrapFormRenderer } from '../../bootstrap-form-renderer';
import { Router } from 'aurelia-router';


@inject(DialogService, ValidationControllerFactory, Router)
export class AssetComponent {

  assetName;
  department;
  countryOfDepartment;
  eMailAdressOfDepartment;
  purchaseDate;
  broken;

  assetVM: AssetVM;

  baseAPIURL = "https://localhost:44386";
  disableResetButton = false;
  disableSendButton = false;
  controller = null;


  rules = ValidationRules
    .ensure('assetName').required().minLength(5)
    .ensure('department').required()
    .ensure('countryOfDepartment').required()
    .ensure('purchaseDate').required().satisfies((value: any, object?: any) => new Date(value) > new Date(new Date().setFullYear(new Date().getFullYear() - 1)))
    .ensure('eMailAdressOfDepartment').required().email()
    .rules;


  constructor(
    private dialogService: DialogService,
    controllerFactory: ValidationControllerFactory,
    private router: Router
  ) {
    this.loadAssets();
    this.controller = controllerFactory.createForCurrentScope();
    this.controller.addRenderer(new BootstrapFormRenderer());
  }

  private loadAssets() {
    fetch(`${this.baseAPIURL}/api/Asset`)
      .then(x => x.json())
      .then(x => {
        this.assetVM = x;

        if (this.assetVM.assets.length > 0)
          this.assetVM.assets.forEach(y => y.purchaseDate = new Date(y.purchaseDate).toLocaleDateString());

        console.log(x);
      });
  }

  async submit() {
    this.controller.validate().then(x => this.postdata(x));
  }


  async postdata(result) {

    if (!result.valid) {
      return;
    }

    const payload = {
      assetName: this.assetName,
      department: this.department,
      eMailAdressOfDepartment: this.eMailAdressOfDepartment,
      countryOfDepartment: this.countryOfDepartment,
      purchaseDate: this.purchaseDate,
      broken: this.broken
    };

    console.log(payload);

    await fetch(`${this.baseAPIURL}/api/Asset`,
      {
        method: "post",
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload),
      })
      .then(response => {

        if (!response.ok)
          response.text().then(text => this.showDialogue("Error", `Request rejected with status ${response.status} and message ${text}`))
        else
          return response.json();

      })
      .then(x => {
        this.router.navigateToRoute('AssetResult');
      })
      .catch(error => {
        console.log(error);
        this.showDialogue("Error", error);
      });

  }


  resetInput() {
    this.dialogService.open({ viewModel: Prompt, model: { message: 'Confirm Reset', description: 'Are you sure you want to reset all data?' }, lock: false }).whenClosed(response => {
      if (!response.wasCancelled) {
        this.clearInput();
      }
      else {
        console.log("User pressed CANCEL")
      }

    });
  }

  clearInput() {
    this.assetName = "";
    this.department = "";
    this.countryOfDepartment = "";
    this.eMailAdressOfDepartment = "";
    this.purchaseDate = "";
    this.broken = false;
  }


  showDialogue(title, description) {
    this.dialogService.open({ viewModel: Prompt, model: { message: title, description: description }, lock: false }).whenClosed(response => {
      console.log(description);
    });
  }


}
