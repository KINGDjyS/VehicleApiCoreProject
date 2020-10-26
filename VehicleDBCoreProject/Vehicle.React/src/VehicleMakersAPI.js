import React from 'react';
import { Provider } from 'mobx-react';
import VehicleMakersProvider from './Components/MakersAPI/VehicleMakeAPIProvider';
import GetVehicleMakers from './Components/MakersAPI/GetVehicleMakers';
import CreateUpdateMaker from './Components/MakersAPI/CreateUpdateMaker';

export default class VehicleMakersAPI extends React.Component {
    render() {
        return (
            <Provider provider={VehicleMakersProvider} >
                <div className="mock">
                    <h1 style={{ textAlign: "center" }}>Vehicle Makers API</h1>
                    <CreateUpdateMaker />
                    <GetVehicleMakers />
                </div>
            </Provider>
        );
    }
}