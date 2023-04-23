import { Typography } from "@mui/material";

const TournamentListCard = (props) => {
  const tournament = props.tournament;
  const startDate = new Date(tournament.startDate);

  if (props.top) {
    return (
      <div className="list-card-top">
        <p className="name-row">{tournament.name}</p>
        <p className="name-row">{tournament.game}</p>
        <div className="date-row">
          <p className="name-row">{startDate.toLocaleDateString()}</p>
          <p className="name-row">{startDate.toLocaleTimeString()}</p>
        </div>
      </div>
    );
  } else {
    return (
      <div className="list-card">
        <img src="https://blogoflegends.com/files/2020/02/Caitlyn_6.jpg" />
        <div className="card-info" >
          <p className="name-row">{tournament.name}</p>
          <p className="name-row">{tournament.game}</p>
          <div className="date-row">
            <p className="name-row">{startDate.toLocaleDateString()}</p>
            <p className="name-row">{startDate.toLocaleTimeString()}</p>
          </div>
        </div>
      </div>
    );
  }
};

export default TournamentListCard;
