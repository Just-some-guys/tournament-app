import axios from "axios";
import { API_SERVER } from "../configs/constants";

class OrganizationApi { 
  static GetOrganization = (id) => {
    return axios.get(`${API_SERVER}organization/${id}`);
  };

  static GetUserOrganizations = (userId) => {
    return axios.get(`${API_SERVER}organization/user/${userId}`);
  };
}

export default OrganizationApi;