import { AssetVM, AssetDTO } from './Models/AssetVM';
require('bootstrap/dist/css/bootstrap.min.css');
require('bootstrap');

export class App {

  assetVM: AssetVM;

  constructor() {
    fetch('https://localhost:5001/api/Asset')
      .then(x => x.json())
      .then(x => {
        this.assetVM = x;

        if (this.assetVM.assets.length > 0)
          this.assetVM.assets.forEach(y => y.purchaseDate = new Date(y.purchaseDate).toLocaleDateString());

        console.log(x);
      });
  }



  public message = 'Hello World!';
}
