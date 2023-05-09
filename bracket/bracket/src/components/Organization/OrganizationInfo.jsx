import { Typography } from "@mui/material";
import OrganizationBanner from "../OrganizationBanner/OrganizationBanner";

const OrganizationInfo = (props) => {
const organization = props.organization;    

    return (
      <div className="organization-main-field">        

        <div className="organization-banner banner-img">
            <img src={organization.banner} alt="" />
        </div>

        <OrganizationBanner logo={
          organization.logo
          
        }
        title={organization.name} >
        
        </OrganizationBanner>
        <p>
        {organization.description}
        </p>       
                   
      </div>
    );
  
};

export default OrganizationInfo;