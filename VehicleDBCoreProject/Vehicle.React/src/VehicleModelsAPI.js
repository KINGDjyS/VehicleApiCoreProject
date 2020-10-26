import React from 'react';
import { Provider } from 'mobx-react';
import VehicleModelsProvider from './Components/ModelsAPI/VehicleModelAPIProvider';
import GetVehicleModels from './Components/ModelsAPI/GetVehicleModels';
import CreateUpdateModel from './Components/ModelsAPI/CreateUpdateModels';

export default class VehicleModelsAPI extends React.Component {
    render() {
        return (
            <Provider provider={VehicleModelsProvider} >
                <div className="mock">
                    <h1 style={{ textAlign: "center" }}>Vehicle Models API</h1>
                    <CreateUpdateModel />
                    <GetVehicleModels />
                </div>
            </Provider>
        );
    }
}