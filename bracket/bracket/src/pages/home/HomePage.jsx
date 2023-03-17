import React, { useEffect, useState } from "react";
import TournamentsList from "../../components/TournamentsList/TournamentsList";

const HomePage = (props) => {
  const [tournaments, setTournaments] = useState([]);
  const [filter, setFilter] = useState();
  const getTournaments = () => {
    fetch(`${process.env.REACT_APP_API_BASE_URL}api/tournament`).then((res) => {
      res.json().then((data) => setTournaments(data));
    });
  };
  useEffect(() => {
    getTournaments();
  }, [filter]);

  return (
    <div>
      <TournamentsList tournaments={tournaments} />
    </div>
  );
};

export default HomePage;
