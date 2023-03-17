import TournamentListCard from "../../components/TournamentListCard/TournamentListCard";

const TournamentsList = (props) => {
  return (
    <div id="tournaments-list">      
      {props.tournaments?.map((tournament) => (
        <TournamentListCard tournament={tournament} />
      ))}
    </div>
  );
};

export default TournamentsList;
