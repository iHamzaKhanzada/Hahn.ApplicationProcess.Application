import { PLATFORM } from 'aurelia-pal';
require('bootstrap/dist/css/bootstrap.min.css');
require('bootstrap');

export class App {

  configureRouter(config, router) {
    config.title = "Aurelia App";
    config.map([
      { route: '', name: 'Home', moduleId: PLATFORM.moduleName("components/asset/asset"), title: 'Home' },
      { route: 'assetresult', name: 'AssetResult', moduleId: PLATFORM.moduleName("components/assetresult/assetresult"), title: 'Asset Result' }

    ])
  }

}

