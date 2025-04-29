import { apiClient } from "./apiClient";

export const UomService = {
    getAll: () =>
      apiClient('/UnitOfMeasure/GetAll', {
        method: 'GET'
      })
};