const TournamentListCard = (props) => {
  const tournament = props.tournament;
  const startDate = new Date(tournament.startDate);

  return (
    <div className="list-card">
      <p className="name-row">{tournament.name}</p>
      <div className="date-row">
        <p>{startDate.toLocaleDateString()}</p>
        <p>{startDate.toTimeString()}</p>
      </div>
    </div>
  );
};

export default TournamentListCard;
