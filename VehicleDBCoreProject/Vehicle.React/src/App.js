import React from 'react';
import './App.css';
import { BrowserRouter, Route } from 'react-router-dom';
import Nav from './Nav';
import VehicleMakersMock from './VehicleMakersMock';
import VehicleModelsMock from './VehicleModelsMock';
import VehicleMakersAPI from './VehicleMakersAPI';
import VehicleModelsAPI from './VehicleModelsAPI';

export default class App extends React.Component{
    render() {
        return (
            <BrowserRouter>
                <Nav />
                <Route exact path='/' component={VehicleMakersMock} />
                <Route path='/ModelsMock' component={VehicleModelsMock} />
                <Route path='/MakersApi' component={VehicleMakersAPI} />
                <Route path='/ModelsApi' component={VehicleModelsAPI} />
            </BrowserRouter>
      );
    }
}

/*
 * 
 */
