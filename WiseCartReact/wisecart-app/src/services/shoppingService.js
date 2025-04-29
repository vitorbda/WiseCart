import { apiClient } from "./apiClient";

export const ShoppingService = {
    getShoppingsByUserId: (userId) =>
      apiClient('/Shopping/GetShoppingByUserId/' + userId, {
        method: 'GET'
      }),
    create: (shoppingVM) => 
        apiClient('/Shopping/CreateShopping/', {
            method: 'POST',
            body: JSON.stringify(shoppingVM)
        }),
    getById: async (id) => 
      apiClient('/Shopping/GetById/' + id, {
        method: 'GET'
      }),
    UpdateDateEnd: (shoppingId, dateEnd) =>
      apiClient(`/Shopping/UpdateDateEnd?shoppingId=${shoppingId}&dateEnd=${dateEnd}`, {
        method: 'PUT'
      })
};