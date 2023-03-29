import { useParams } from "react-router";

const TournamentPage = () => {
  const { id } = useParams();
  return <h1>TournamentPage {id}</h1>;
};

export default TournamentPage;
