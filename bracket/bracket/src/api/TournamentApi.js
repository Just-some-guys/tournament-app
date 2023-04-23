import axios from "axios";
import { API_SERVER } from "../configs/constants";

class TournamentApi {
  static GetTopTournaments = () => {
    return axios.get(`${API_SERVER}tournament/top`);
  };

  static GetTournaments = () => {
    return axios.get(`${API_SERVER}tournament`);
  };

  static GetTournament = (id) => {
    return axios.get(`${API_SERVER}tournament/${id}`);
  };
}

export default TournamentApi;
