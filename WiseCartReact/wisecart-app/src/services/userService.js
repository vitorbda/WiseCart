import { apiClient } from "./apiClient";

export const UserService = {
    login: (loginProps) =>
      apiClient('/Authentication/Authenticate', {
        method: 'POST',
        body: JSON.stringify(loginProps),
      }),

      register: (registerProps) =>
        apiClient('/User/Register', {
          method: 'POST',
          body: JSON.stringify(registerProps)
        })
};