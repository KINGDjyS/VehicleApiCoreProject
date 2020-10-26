import React from 'react';

class VehicleMaker extends React.Component{
	render() {
		return (
			<tr>
				<td>{this.props.maker.name}</td>
				<td>{this.props.maker.abrv}</td>
				<td><button onClick={this.props.editMaker.bind(this, this.props.maker.vehicleMakeId)}>Edit</button></td>
				<td><button onClick={this.props.removeMaker.bind(this, this.props.maker.vehicleMakeId)}>Remove</button></td>
			</tr>
		)
		
    }
	
}

export default VehicleMaker;