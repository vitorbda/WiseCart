
export interface MarketViewModel {
    id: string;
    name: string;
  }
  
  export interface PurchaseViewModel {
    id: string;
    unitOfMeasureId: string
    unitOFMeasure_Abbreviation: string;
    quantity: number;
    price: number;
    productId: string;
    product: ProductViewModel
  }
  
  export interface ShoppingViewModel {
    id: string;
    userId: string;
    dateStart: Date;
    dateEnd?: Date;
    market?: MarketViewModel;
    purchases: PurchaseViewModel[];
  }
  
  export interface ProductViewModel {
    id: string;
    code: string;
    name: string;
    brands: string;
  }

  export interface UnitOfMeasureViewModel {
    id: string;
    name: string;
    abbreviation: string;
  }