import React from 'react';
import { observer, inject } from 'mobx-react';
import VehicleMaker from '../MakersAPI/VehicleMaker';
import paging from '../../Common/Paging';
import filtering from '../../Common/Filtering';
import sorting from '../../Common/Sorting';

class GetVehicleMakers extends React.Component {

    componentDidMount() {
        sorting.sortBy = "name";
        this.props.provider.getVehicleMakersAsync();
    }

    searchMaker = (e) => {
        if (e.key === "Enter") {
            filtering.search = e.target.value;
            this.props.provider.getVehicleMakersAsync();
        }
    }

    onEdit = (vehicleMakeId) => {
        this.props.provider.id = vehicleMakeId;
        this.props.provider.edit();
    }
    
    render() {
        return (
            <div >
                <div>
                    <input type="search" onKeyPress={this.searchMaker} placeholder="Search" />
            </div>
            <div>
                <table border="1">
                    <thead>
                        <tr>
                                <th allign="center"><input type="button" onClick={this.props.provider.nameSort} value="Name" /></th>
                                <th allign="center"><input type="button" onClick={this.props.provider.abrvSort} value="Abrv" /></th>
                        </tr>
                    </thead>
                    <tbody>
                            {this.props.provider.makeData.map(maker => (
                                <VehicleMaker key={maker.vehicleMakeId} editMaker={this.onEdit} removeMaker={this.props.provider.removeMakerAsync} maker={maker} />
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

export default inject("provider")(observer(GetVehicleMakers));