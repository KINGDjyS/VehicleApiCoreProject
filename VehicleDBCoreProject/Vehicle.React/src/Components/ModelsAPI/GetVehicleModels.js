import React from 'react';
import { observer, inject } from 'mobx-react';
import VehicleModel from './VehicleModel';
import paging from '../../Common/Paging';
import filtering from '../../Common/Filtering';
import sorting from '../../Common/Sorting';

class GetVehicleModels extends React.Component {

    componentDidMount() {
        sorting.sortBy = "";
        this.props.provider.getVehicleModelsAsync();
    }

    searchModel = (e) => {
        if (e.key === "Enter") {
            filtering.search = e.target.value;
            this.props.provider.getVehicleModelsAsync();
        }
    }

    onEdit = (vehicleModelId) => {
        this.props.provider.id = vehicleModelId;
        this.props.provider.edit();
    }
    
    render() {
        return (
            <div >
                <div>
                    <input type="search" onKeyPress={this.searchModel} placeholder="Search" />
            </div>
            <div>
                <table border="1">
                    <thead>
                            <tr>
                                <th allign="center"><input type="button" onClick={this.props.provider.makeSort} value="VehicleMakeId" /></th>
                                <th allign="center"><input type="button" onClick={this.props.provider.nameSort} value="Name" /></th>
                                <th allign="center"><input type="button" onClick={this.props.provider.abrvSort} value="Abrv" /></th>
                        </tr>
                    </thead>
                    <tbody>
                            {this.props.provider.modelData.map(model => (
                                <VehicleModel key={model.vehicleModelId} editModel={this.onEdit} removeModel={this.props.provider.removeModelAsync} model={model} />
                        ))}
                    </tbody>
                    </table>
                    <div>
                        {paging.hasPrevious && (<button onClick={this.props.provider.previousPage}>Previous</button>)}
                        {paging.hasNext && (<button onClick={this.props.provider.nextPage}>Next</button>)}
                    </div>
                </div>
            </div>
        )
    }

}

export default inject("provider")(observer(GetVehicleModels));