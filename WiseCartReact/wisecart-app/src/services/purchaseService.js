import { apiClient } from "./apiClient";

export const PurchaseService = {
    GetByShoppingId: async (shoppingId) => 
        apiClient('/Purchase/GetByShoppingId/' + shoppingId, {
          method: 'GET'
        }),
    UpdatePurchase: async (purchase) => 
      apiClient('/Purchase/UpdatePurchase', {
        method: 'PUT',
        body: JSON.stringify(purchase)
      }),
    CreatePurchase: (purchaseVM) =>
      apiClient('/Purchase/CreatePurchase', {
        method: 'POST',
        body: JSON.stringify(purchaseVM)
      }),
      DeletePurchase: (id) =>
        apiClient('/Purchase/DeletePurchase/' + id, {
          method: 'DELETE'
        })
}