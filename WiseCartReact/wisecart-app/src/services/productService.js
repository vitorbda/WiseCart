import { apiClient } from "./apiClient";

export const ProductService = {
    get: (code) =>
      apiClient('/Product/Get/' + code, {
        method: 'GET'
      }),
    createProduct: (productVM) => 
      apiClient('/Product/CreateProduct/', {
        method: 'POST',
        body: JSON.stringify(productVM)
      })
};