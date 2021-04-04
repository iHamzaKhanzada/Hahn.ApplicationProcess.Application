import { AssetVM, AssetDTO } from './Models/AssetVM';
require('bootstrap/dist/css/bootstrap.min.css');
require('bootstrap');

export class App {


  assetName = "Air Conditioner";
  department = "HQ";
  countryOfDepartment = "Bangladesh";
  eMailAdressOfDepartment = "noreply@HQ.com";
  purchaseDate = "2021-01-01";
  broken = true;

  assetVM: AssetVM;

  constructor() {
    this.loadAssets();
  }

  private loadAssets() {
    fetch('https://localhost:5001/api/Asset')
      .then(x => x.json())
      .then(x => {
        this.assetVM = x;

        if (this.assetVM.assets.length > 0)
          this.assetVM.assets.forEach(y => y.purchaseDate = new Date(y.purchaseDate).toLocaleDateString());

        console.log(x);
      });
  }

  public async postdata(): Promise<boolean> {

    const payload = {
      assetName: this.assetName,
      department: this.department,
      eMailAdressOfDepartment: this.eMailAdressOfDepartment,
      countryOfDepartment: this.countryOfDepartment,
      purchaseDate: this.purchaseDate,
      broken: this.broken
    };

    console.log(payload);

    try {
      await fetch("https://localhost:5001/api/Asset", {
        method: "post",
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload),
      }).then(response => response.json()).then(x => this.loadAssets());

      return true;

    } catch (e) {
      console.log("Error: ", e.Message); // handle the error logging however you need.
      return false;
    }

  }


}
