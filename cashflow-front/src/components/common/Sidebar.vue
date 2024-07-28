<script setup lang="ts">
import { ref } from 'vue';

const isOpened = ref(false);

const ToggleMenu = () => {
  isOpened.value = !isOpened.value;
};

</script>

<template>
  <aside class='sidebar' :class="`${isOpened && 'is-opened'}`">
    <div class='logo'>
      <img src='../../assets/vue.svg'>
    </div>

    <div class="menu-toggle-wrap">
			<button class="menu-toggle" @click='ToggleMenu'>
				<span class="material-symbols-outlined">keyboard_double_arrow_right</span>
			</button>
		</div>

    <h3>Menu</h3>
		<div class="menu">
			<router-link to="/dashboard" class="button">
        <span class="material-symbols-outlined">dashboard</span>
				<span class="text">Dashboard</span>
			</router-link>
			<router-link to="/expenses" class="button">
				<span class="material-symbols-outlined">attach_money</span>
				<span class="text">Expenses</span>
			</router-link>
			<router-link to="/team" class="button">
				<span class="material-symbols-outlined">group</span>
				<span class="text">Team</span>
			</router-link>
			<router-link to="/contact" class="button">
				<span class="material-symbols-outlined">email</span>
				<span class="text">Contact</span>
			</router-link>
		</div>

		<div class="flex"></div>
		
		<div class="menu">
			<router-link to="/settings" class="button">
				<span class="material-symbols-outlined">settings</span>
				<span class="text">Settings</span>
			</router-link>
		</div>

  </aside>
</template>

<style scoped lang="scss">

aside{
  display: flex;
  flex-direction: column;
  width: calc(2rem + 32px);
  min-height: 100vh;
  overflow: hidden;
  padding: 1rem;

  background-color: var(--secondary);
  color: var(--lightfont);

  transition: 0.2s ease-out;

  .flex {
		flex: 1 1 0%;
	}

  .menu-toggle-wrap {
    display: flex;
    justify-content: flex-end;
    margin-bottom: 1rem;

    position: relative;
    top: 0;
    transition: 0.2s ease-out;

    .menu-toggle {
      transition: 0.2s ease-out;

      .material-symbols-outlined {
        font-size: 2rem;
        color: var(--lightfont);
        transition: 0.2s ease-out;
      }

      &:hover {
        .material-symbols-outlined {
          color: var(--menubutton);
          transform: translateX(0.5rem);
        }
      }
    }
  }

  &.is-opened {
    width: 300px;

    .menu-toggle-wrap {
      top: -3rem;

      .menu-toggle {
        transform: rotate(-180deg);
      }
    }
    h3, .button .text {
			opacity: 1;
		}

		.button {
			.material-symbols-outlined {
				margin-right: 1rem;
			}
		}

		.footer {
			opacity: 0;
		}
  }

  h3, .button .text {
		opacity: 0;
		transition: opacity 0.3s ease-in-out;
	}

	h3 {
		color: var(--grey);
		font-size: 0.875rem;
		margin-bottom: 0.5rem;
		text-transform: uppercase;
	}

	.menu {
		margin: 0 -1rem;

		.button {
			display: flex;
			align-items: center;
			text-decoration: none;

			transition: 0.2s ease-in-out;
			padding: 0.5rem 1rem;

			.material-symbols-outlined {
				font-size: 2rem;
				color: var(--lightfont);
				transition: 0.2s ease-in-out;
			}
			.text {
				color: var(--lightfont);
				transition: 0.2s ease-in-out;
			}

			&:hover {
				background-color: var(--menubutton);

				.material-symbols-outlined, .text {
					color: var(--secondary);
				}
			}

			&.router-link-exact-active {
				background-color: var(--menubutton);
				border-right: 5px solid var(--secondary);

				.material-symbols-outlined, .text {
					color: var(--secondary);
				}
			}
		}
	}

	.footer {
		opacity: 0;
		transition: opacity 0.3s ease-in-out;

		p {
			font-size: 0.875rem;
			color: var(--grey);
		}
	}

  @media (max-width: 768px) {
    position: fixed;
    z-index: 99;
  }
}

</style>
