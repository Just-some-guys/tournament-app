import {
  DoubleEliminationBracket,
  Match,
} from "@g-loot/react-tournament-brackets";
import React, { useEffect } from "react";

function App() {
  const [bracket, setBracket] = React.useState();

  useEffect(() => {
    getBracket();
  }, []);

  const getBracket = () => {
    fetch("https://localhost:7143/api/Bracket").then(async (result) => {
      var data = await result.json();
      setBracket({ upper: data.upperBranch, lower: data.lowerBranch });
    });
  };

  return (
    <div className="App">
      {bracket && (
        <DoubleEliminationBracket matches={bracket} matchComponent={Match} />
      )}
    </div>
  );
}

export default App;
