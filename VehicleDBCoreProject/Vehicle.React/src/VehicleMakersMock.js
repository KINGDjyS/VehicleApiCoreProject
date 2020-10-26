import React from 'react';
import { Provider } from 'mobx-react';
import VehicleMakerTable from './Components/MakersMock/VehicleMakerTable';
import VehicleMakersProvider from './Components/MakersMock/VehicleMakersProvider';

export default class VehicleMakersMock extends React.Component {
    render() {
        return (
            <Provider provider={VehicleMakersProvider} >
                <div className="mock">
                    <h1 style={{ textAlign: "center" }}>Vehicle Makers Mock</h1>
                    <VehicleMakerTable />
                </div>
            </Provider>
        );
    }
}