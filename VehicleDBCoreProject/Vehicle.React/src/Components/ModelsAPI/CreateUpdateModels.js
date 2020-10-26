import React from 'react';
import { observer, inject } from 'mobx-react';
import { runInAction } from 'mobx';

class CreateUpdateModels extends React.Component {

    componentDidMount() {
        this.refs.vehicleMakeId.value = "";
        this.refs.name.value = "";
        this.refs.abrv.value = "";
    }

    onSubmit = (e) => {
        e.preventDefault();
        if (this.props.provider.isEdit) {
            this.props.provider.updateVehicleModelAsync({
                vehicleMakeId: this.refs.vehicleMakeId.value,
                name: this.props.provider.name,
                abrv: this.props.provider.abrv
            });
            this.refs.vehicleMakeId.value = "";
            this.refs.name.value = "";
            this.refs.abrv.value = "";
            this.props.provider.isEdit = false;
        } else {
            this.props.provider.createVehicleModelAsync({
                vehicleMakeId: this.refs.vehicleMakeId.value,
                name: this.refs.name.value,
                abrv: this.refs.abrv.value
            });
            this.refs.vehicleMakeId.value = "";
            this.refs.name.value = "";
            this.refs.abrv.value = "";
        }
    }

    onChange = () => {
        runInAction(() => {
            this.props.provider.vehicleMakeId = this.refs.vehicleMakeId.value;
            this.props.provider.name = this.refs.name.value;
            this.props.provider.abrv = this.refs.abrv.value;
        })
       
    }

    render() {
        return (
            <div>
                <form>
                    <input type="text" onChange={this.onChange} ref="vehicleMakeId" placeholder="Enter Maker ID" value={this.props.provider.vehicleMakeId} />
                    <br />
                    <input type="text" onChange={this.onChange} ref="name" placeholder="Enter Model Name" value={this.props.provider.name} />
                    <br />
                    <input type="text" onChange={this.onChange} ref="abrv" placeholder="Enter Model Abrv" value={this.props.provider.abrv}/>
                    <button onClick={this.onSubmit} >Submit</button>
                </form>
            </div>
         )
    }
}

export default inject("provider")(observer(CreateUpdateModels));