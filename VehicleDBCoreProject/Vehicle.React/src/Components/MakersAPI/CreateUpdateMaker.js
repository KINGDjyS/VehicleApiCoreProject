import React from 'react';
import { observer, inject } from 'mobx-react';
import { runInAction } from 'mobx';

class CreateUpdateMaker extends React.Component {

    componentDidMount() {
        this.refs.name.value = "";
        this.refs.abrv.value = "";
    }

    onSubmit = (e) => {
        e.preventDefault();
        if (this.props.provider.isEdit) {
            this.props.provider.updateVehicleMakerAsync({
                name: this.props.provider.name,
                abrv: this.props.provider.abrv
            });
            this.refs.name.value = "";
            this.refs.abrv.value = "";
            this.props.provider.isEdit = false;
        } else {
            this.props.provider.createVehicleMakerAsync({
                name: this.refs.name.value,
                abrv: this.refs.abrv.value
            });
            this.refs.name.value = "";
            this.refs.abrv.value = "";
        }
    }

    onChange = () => {
        runInAction(() => {
            this.props.provider.name = this.refs.name.value;
            this.props.provider.abrv = this.refs.abrv.value;
        })
       
    }

    render() {
        return (
            <div>
                <form>
                    <input type="text" onChange={this.onChange} ref="name" placeholder="Enter Maker Name" value={this.props.provider.name} />
                    <br />
                    <input type="text" onChange={this.onChange} ref="abrv" placeholder="Enter Maker Abrv" value={this.props.provider.abrv}/>
                    <button onClick={this.onSubmit} >Submit</button>
                </form>
            </div>
         )
    }
}

export default inject("provider")(observer(CreateUpdateMaker));