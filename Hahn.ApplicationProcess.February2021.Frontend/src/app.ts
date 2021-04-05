import { DialogService } from 'aurelia-dialog';
import { Prompt } from './components/mymodal';
import { AssetVM } from './models/AssetVM';
import { inject } from 'aurelia-framework';
require('bootstrap/dist/css/bootstrap.min.css');
require('bootstrap');

@inject(DialogService)
export class App {

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


  constructor(private dialogService: DialogService) {
    this.loadAssets();
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

  showDialogue(title, description) {
    this.dialogService.open({ viewModel: Prompt, model: { message: title, description: description }, lock: false }).whenClosed(response => {
      console.log(description);
    });
  }

  async postdata() {

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

        if (!response.ok) {

          response.text().then( text => this.showDialogue("Error", `Request rejected with status ${response.status} and message ${text}`))

        }
        else {
          return response.json();
        }

      })
      .then(x => this.loadAssets())
      .catch(error => {

        console.log(error);
        this.showDialogue("Error", error);


      });

  }

  resetInput() {
    this.dialogService.open({ viewModel: Prompt, model: { message: 'Confirm Reset', description: 'Are you sure you want to reset all data?' }, lock: false }).whenClosed(response => {
      if(!response.wasCancelled)
      {
        this.assetName = "";
        this.department = "";
        this.countryOfDepartment = "";
        this.eMailAdressOfDepartment = "";
        this.purchaseDate = "";
        this.broken = false;

      }
      else {
        console.log("User pressed CANCEL")

      }

    });
  }

}

