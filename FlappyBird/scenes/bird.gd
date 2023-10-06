extends CharacterBody2D

class_name Bird

var gravity = 800
var jump_force = 200
var max_speed = 350

@onready var animation_player = $AnimationPlayer

func _ready():
	velocity = Vector2(0, 0)
	animation_player.play("flap_wings")
	
func _physics_process(delta):
	if Input.is_mouse_button_pressed(1) or Input.is_action_just_pressed("jump"):
		velocity.y = -jump_force
	
	velocity.y += gravity * delta
	
	velocity.y = min(velocity.y, max_speed)
		
	move_and_collide(velocity * delta)
	

