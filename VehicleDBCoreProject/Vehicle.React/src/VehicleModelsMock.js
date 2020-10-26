import React from 'react';
import { Provider } from 'mobx-react';
import VehicleModelTable from './Components/ModelsMock/VehicleModelTable';
import VehicleModelsProvider from './Components/ModelsMock/VehicleModelsProvider';

export default class VehicleMakersMock extends React.Component {
    render() {
        return (
            <Provider provider={VehicleModelsProvider} >
                <div className="mock">
                    <h1 style={{ textAlign: "center" }}>Vehicle Models Mock</h1>
                    <VehicleModelTable />
                </div>
            </Provider>
        );
    }
}