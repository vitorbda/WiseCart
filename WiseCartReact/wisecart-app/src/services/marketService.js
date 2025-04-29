import { apiClient } from "./apiClient";

export const MarketService = {
    get: () =>
      apiClient('/Market/GetAll', {
        method: 'GET'
      }),
};