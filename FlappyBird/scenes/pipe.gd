extends RigidBody2D


func _physics_process(delta):
	position.x -= 100 * delta
