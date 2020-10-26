import React from 'react';

class VehicleModel extends React.Component {
	render() {
		return (
			<tr>
				<td>{this.props.model.vehicleMakeId}</td>
				<td>{this.props.model.name}</td>
				<td>{this.props.model.abrv}</td>
				<td><button onClick={this.props.editModel.bind(this, this.props.model.vehicleModelId)}>Edit</button></td>
				<td><button onClick={this.props.removeModel.bind(this, this.props.model.vehicleModelId)}>Remove</button></td>
			</tr>
		)

	}

}

export default VehicleModel;