<template>
  <div class="navbar">
    <hamburger :is-active="sidebar.opened" class="hamburger-container" @toggleClick="toggleSideBar" />

    <breadcrumb class="breadcrumb-container" />

    <div class="right-menu">

      <el-button @click="logout" style="top: 10px;left:85%;position:absolute">
        <span>退出登录</span>
      </el-button>

      <el-dropdown class="avatar-container right-menu-item hover-effect" trigger="click">
        <div class="avatar-wrapper">
          <img :src="avatar" class="user-avatar">
          <i class="el-icon-caret-bottom"></i>
        </div>
        <el-dropdown-menu slot="dropdown" class="user-dropdown">
          <!--          <router-link to="/profile/index">-->
          <!--            <el-dropdown-item>-->
          <!--              个人中心-->
          <!--            </el-dropdown-item>-->
          <!--          </router-link>-->
          <!--          <a target="_blank" href="https://github.com/PanJiaChen/vue-admin-template/">-->
          <!--            <el-dropdown-item>Github</el-dropdown-item>-->
          <!--          </a>-->
          <!--          <a target="_blank" href="https://panjiachen.github.io/vue-element-admin-site/#/">-->
          <!--            <el-dropdown-item>Docs</el-dropdown-item>-->
          <!--          </a>-->
        </el-dropdown-menu>
      </el-dropdown>
    </div>
  </div>
</template>

<script>
// import { mapGetters } from 'vuex'
import { mapState } from 'pinia'
import { useSidebar } from '../../stores/app'
import { useSetting } from '../../stores/setting'
import pinia from '../../stores/index'

import Breadcrumb from '@/components/Breadcrumb/index.vue'
import Hamburger from '@/components/Hamburger/index.vue'
import Screenfull from '@/components/Screenfull/index.vue'
import Search from '@/components/HeaderSearch/index.vue'
import defaultAvatar from '@/assets/images/default_avatar.png'

const sidebar = useSidebar(pinia)

export default {
  components: {
    Breadcrumb,
    Hamburger,
    Screenfull,
    Search
  },
  computed: {
    ...mapState(useSidebar, {
      sidebar: store => store.sidebar,
      device: store => store.device
    })
  },
  data() {
    return {
      avatar: defaultAvatar
    }
  },
  methods: {
    toggleSideBar() {
      // this.$store.dispatch('app/toggleSideBar')
      sidebar.toggleSideBar()
    },
    logout() {
      // await this.$store.dispatch('user/logout')
      // this.$store.dispatch('user/logout')
      this.$router.push(`/Login`)
    }
  }
}
</script>

<style lang="scss" scoped>
.navbar {
  height: 50px;
  overflow: hidden;
  position: relative;
  background: #fff;
  box-shadow: 0 1px 4px rgba(0, 21, 41, .08);

  .hamburger-container {
    line-height: 46px;
    height: 100%;
    float: left;
    cursor: pointer;
    transition: background .3s;
    -webkit-tap-highlight-color: transparent;

    &:hover {
      background: rgba(0, 0, 0, .025)
    }
  }

  .breadcrumb-container {
    float: left;
  }

  .right-menu {
    float: right;
    height: 100%;
    line-height: 50px;

    &:focus {
      outline: none;
    }

    .right-menu-item {
      display: inline-block;
      padding: 0 8px;
      height: 100%;
      font-size: 18px;
      color: #5a5e66;
      vertical-align: text-bottom;

      &.hover-effect {
        cursor: pointer;
        transition: background .3s;

        &:hover {
          background: rgba(0, 0, 0, .025)
        }
      }
    }

    .avatar-container {
      margin-right: 30px;

      .avatar-wrapper {
        margin-top: 5px;
        position: relative;

        .user-avatar {
          cursor: pointer;
          width: 40px;
          height: 40px;
          border-radius: 10px;
        }

        .el-icon-caret-bottom {
          cursor: pointer;
          position: absolute;
          right: -20px;
          top: 25px;
          font-size: 12px;
        }
      }
    }
  }
}
</style>
