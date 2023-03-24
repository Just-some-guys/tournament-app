import TournamentListCard from "../../components/TournamentListCard/TournamentListCard";

const TournamentsList = (props) => {
  return (
    <div className={"tournaments-list " + (props.top ? "top" : "")}>
      {props.tournaments?.map((tournament) => (
        <TournamentListCard top={props.top} tournament={tournament} />
      ))}
    </div>
  );
};

export default TournamentsList;
