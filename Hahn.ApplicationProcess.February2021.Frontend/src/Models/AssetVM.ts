export interface AssetVM {
  assets: AssetDTO[];
  createEnabled: boolean;
}

export interface AssetDTO {
  id: number;
  assetName: string;
  department: string;
  countryOfDepartment:string;
  eMailAdressOfDepartment: string;
  purchaseDate: string;
  broken: boolean;
}
