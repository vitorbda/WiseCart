import { ShoppingViewModel } from "../models/viewModel/models";

export const formatDate = (date: Date): string => {
    return new Date(date).toLocaleString("pt-BR", {
      day: "2-digit",
      month: "2-digit",
      year: "numeric",
      hour: "2-digit",
      minute: "2-digit",
    });
  };
    
  export const getDateEndString = (shopping: ShoppingViewModel): string =>
    shopping.dateEnd ? formatDate(shopping.dateEnd) : "Em andamento";
      
  export const isActive = (shopping: ShoppingViewModel): boolean =>
    !shopping.dateEnd;
  