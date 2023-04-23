const OrganizationBanner = (props) => {
  return (
    <div className="oraganization-banner ">
      <img src={props.logo} /> <span>{props.title}</span> 
      <a href="ссылка на кнопку редактирования организации(только для владельца)"><img className="edit-button" src="https://cdn-icons-png.flaticon.com/512/61/61094.png" /></a>
    </div>
  );
};

export default OrganizationBanner;
