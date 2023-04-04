const OrganizationBanner = (props) => {
  return (
    <div className="oraganization-banner">
      <img src={props.logo} /> <span>{props.title}</span>
    </div>
  );
};

export default OrganizationBanner;
