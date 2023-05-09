const UserOrganization = (props) => {
    return (
      <div className="oraganization-banner">
        <img src={props.organization.logo} /> <span>{props.organization.name}</span> <span>{props.organization.role}</span>
      </div>
    );
  };
  
  export default UserOrganization;